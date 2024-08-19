import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import OptionModel from 'src/app/modules/shared/models/option.model';
import { AuthService } from 'src/app/modules/shared/services/auth.service';
import { DownloadMethodLabel, DownloadMethod } from '../../enum/download-method.enum';
import { FileReportModel } from '../../models/report.model';
import { FilesService } from '../../services/home.service';
import { LogService } from '../../services/log.service';
import { Subscription } from 'rxjs';
import { FileFilterModel } from '../../models/filter.model';
import { MatTableDataSource } from '@angular/material/table';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit, OnDestroy {

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

  public dataSource = new MatTableDataSource<FileReportModel>();
  public displayedColumns: string[] = ['fileId', 'fileName', 'fileDownloadDirectory', 'fileDownloadMethod', 'username', 'fileDownloadTime'];
  private subscription: Subscription;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private router: Router,
    private titleService: Title,
    private filesService: FilesService,
    private cdr: ChangeDetectorRef
  ) { }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  ngOnInit(): void {
    this.titleService.setTitle('Reports');
    this.initForm();
    this.filter();
  }

  initForm(): void {
    this.form = this.formBuilder.group({
      fileId: [''],
      fileName: [''],
      fileDownloadDirectory: [''],
      fileDownloadMethod: [null],
      username: [''],
      fileDownloadTimeStart: [''],
      fileDownloadTimeEnd: ['']
    });
  }

  public isControlEmpty(controlName: string): boolean {
    return !this.form.controls[controlName].value;
  }

  public resetControl(controlName: string): void {
    this.form.controls[controlName].setValue('');
  }

  public resetForm(): void {
    this.form.reset();
  }

  public filter(): void {
    let model: FileFilterModel = {
      fileId: this.form.controls.fileId.value,
      fileName: this.form.controls.fileName.value,
      fileDownloadDirectory: this.form.controls.fileDownloadDirectory.value,
      fileDownloadMethod: this.form.controls.fileDownloadMethod.value,
      fileDownloadTimeStart: this.form.controls.fileDownloadTimeStart.value ? this.form.controls.fileDownloadTimeStart.value.toISOString() : null,
      fileDownloadTimeEnd: this.form.controls.fileDownloadTimeEnd.value ? this.form.controls.fileDownloadTimeEnd.value.toISOString() : null,
      username: this.form.controls.username.value
    };

    this.subscription = this.filesService.getReport(model).subscribe(
      (response) => {
        this.errorMessage = null;
        this.dataSource.data = response.Items;
      },
      (error) => {
        console.log(error);
        this.errorMessage = error.message;
      }
    );
  }
}
