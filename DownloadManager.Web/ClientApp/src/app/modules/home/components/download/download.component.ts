import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl, ValidationErrors } from '@angular/forms';
import { DownloadMethod, DownloadMethodLabel } from '../../enum/download-method.enum';
import OptionModel from 'src/app/modules/shared/models/option.model';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/modules/shared/services/auth.service';
import { FilesService } from '../../services/home.service';
import { DownloadModel } from '../../models/download.model';
import { LogService } from '../../services/log.service';
import { Subscription } from 'rxjs';
import { LogEntry } from '../../models/log.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.scss']
})
export class DownloadComponent implements OnInit, OnDestroy {
  public form: FormGroup;
  public errorMessage: string;
  public downloadMethodLabel = DownloadMethodLabel;
  public downloadMethodOptions: OptionModel[] = [
    {
      name: this.downloadMethodLabel.get(DownloadMethod.BeginInvoke),
      value: DownloadMethod.BeginInvoke
    },
    {
      name: this.downloadMethodLabel.get(DownloadMethod.Thread),
      value: DownloadMethod.Thread
    },
    {
      name: this.downloadMethodLabel.get(DownloadMethod.ThreadPool),
      value: DownloadMethod.ThreadPool
    },
    {
      name: this.downloadMethodLabel.get(DownloadMethod.BackgroundWorker),
      value: DownloadMethod.BackgroundWorker
    },
    {
      name: this.downloadMethodLabel.get(DownloadMethod.Task),
      value: DownloadMethod.Task
    }
  ];

  private logSubscription: Subscription;
  public dataSource = new MatTableDataSource<LogEntry>();
  public displayedColumns: string[] = ['datetime', 'worknumber', 'threadId', 'message'];

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private titleService: Title,
    private filesService: FilesService,
    public logService: LogService
  ) { }

  ngOnDestroy(): void {
    if (this.logSubscription) {
      this.logSubscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.titleService.setTitle('Download');
    this.initForm();
    this.logSubscription = this.logService.getLogs().subscribe(logs => {
      this.dataSource.data = logs;
    });
  }

  initForm(): void {
    this.form = this.formBuilder.group({
      fileUrl: ['https://i.redd.it/ufxj58wy79w81.jpg', [Validators.required, this.urlValidator]],
      fileName: ['file', [Validators.required, this.fileNameValidator]],
      destinationFolder: ['C:\\DownloadManagerFolder', [Validators.required, this.windowsPathValidator]],
      downloadMethod: [DownloadMethod.BeginInvoke, Validators.required]
    });
  }

  download(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    let model: DownloadModel = {
      fileName: this.form.controls.fileName.value,
      fileDownloadDirectory: this.form.controls.destinationFolder.value,
      url: this.form.controls.fileUrl.value,
      fileDownloadMethod: this.form.controls.downloadMethod.value
    };

    this.filesService.download(model).subscribe(
      (response) => {
        this.errorMessage = null;
      },
      (error) => {
        console.log(error);
        if (error.status === 400) {
          this.errorMessage = 'Invalid form.';
        } else {
          this.errorMessage = error.message;
        }
      }
    );
  }

  clear() {
    this.logService.clear().subscribe(() => {
      this.dataSource.data = [];
    });
  }

  private urlValidator(control: AbstractControl): ValidationErrors | null {
    const urlPattern = /^(https?|ftp):\/\/[^\s/$.?#].[^\s]*$/i;
    return urlPattern.test(control.value) ? null : { invalidUrl: true };
  }

  private fileNameValidator(control: AbstractControl): ValidationErrors | null {
    const invalidChars = /[<>:"/\\|?*\x00-\x1F]/;
    return invalidChars.test(control.value) ? { invalidFileName: true } : null;
  }

  private windowsPathValidator(control: AbstractControl): ValidationErrors | null {
    const windowsPathPattern = /^[a-zA-Z]:\\(?:[a-zA-Z0-9]+\\?)*$/;
    return windowsPathPattern.test(control.value) ? null : { invalidWindowsPath: true };
  }
}
