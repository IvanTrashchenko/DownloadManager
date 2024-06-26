import { DownloadMethod } from "../enum/download-method.enum";

export interface FileReportModel {
    fileId: number;
    fileName: string;
    fileDownloadDirectory: string;
    fileDownloadMethod: DownloadMethod;
    fileDownloadTime: Date;
    username: string;
}