import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DownloadMethod, DownloadMethodLabel } from '../../enum/download-method.enum';
import OptionModel from 'src/app/modules/shared/models/option.model';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/modules/shared/services/auth.service';
import { FilesService } from '../../services/home.service';
import { DownloadModel } from '../../models/download.model';

@Component({
  selector: 'app-download',
  templateUrl: './download.component.html',
  styleUrls: ['./download.component.scss']
})
export class DownloadComponent implements OnInit {
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
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private titleService: Title,
    private filesService: FilesService,
    //public signalRService: SignalRService
  ) { }

  ngOnInit(): void {
    this.titleService.setTitle('Download');
    this.initForm();
  }

  initForm(): void {
    this.form = this.formBuilder.group({
      fileUrl: ['https://i.redd.it/ufxj58wy79w81.jpg', Validators.required],
      fileName: ['file', Validators.required],
      destinationFolder: ['C:\\DownloadManagerFolder', Validators.required],
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
        //console.log(response);
      },
      (error) => {
        console.log(error);
        if (error.status === 400) {
          this.errorMessage = 'Invalid form.';
        } else if (error.status === 500) {
          this.errorMessage = 'An error occurred on the server. Please try again later.';
        } else {
          this.errorMessage = 'An unknown error occurred. Please try again.';
        }
      }
    );
  }
}
