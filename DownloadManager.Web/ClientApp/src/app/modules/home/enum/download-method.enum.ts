export enum DownloadMethod {
    BeginInvoke = 1,
    Thread = 2,
    ThreadPool = 3,
    BackgroundWorker = 4,
    Task = 5
}

export const DownloadMethodLabel = new Map<DownloadMethod, string>([
    [DownloadMethod.BeginInvoke, 'BeginInvoke'],
    [DownloadMethod.Thread, 'Thread'],
    [DownloadMethod.ThreadPool, 'ThreadPool'],
    [DownloadMethod.BackgroundWorker, 'BackgroundWorker'],
    [DownloadMethod.Task, 'Task']
]);
