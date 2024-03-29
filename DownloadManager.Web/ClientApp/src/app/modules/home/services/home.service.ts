import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { BaseService } from '../../shared/services/base.service';
import { DownloadModel } from '../models/download.model';
import { FileFilterModel } from '../models/filter.model';
import { EntityResponse } from '../../shared/models/entity-response.model';
import { FileReportModel } from '../models/report.model';

@Injectable({
  providedIn: 'root'
})
export class FilesService extends BaseService {
  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl, 'api/files/');
  }

  download(model: DownloadModel): Observable<any> {
    return this.post('download', model);
  }

  getReport(model: FileFilterModel): Observable<EntityResponse<FileReportModel>> {
    return this.get<EntityResponse<FileReportModel>>(``, model);
  }
}
