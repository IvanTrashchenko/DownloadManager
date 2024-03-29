export interface FileReportModel {
    fileId: number;
    fileName: string;
    fileDownloadDirectory: string;
    fileDownloadMethod: number;
    fileDownloadTime: Date;
    userName: string;
}