import { DownloadMethod } from "../enum/download-method.enum";

export interface DownloadModel {
    fileName: string;
    fileDownloadDirectory: string;
    url: string;
    fileDownloadMethod: DownloadMethod;
}