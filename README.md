# DownloadManager
✔️1. Создать приложение, позволяющее пользователю загружать файл в указанную директорию. Реализовать возможность выбора способа скачивания файла:

* Delegate.BeginInvoke
* Thread
* ThreadPool
* BackgroundWorker
* Task

Сохранять журнал загрузок в базу данных с возможностью редактирования данного журнала.

✔️2. Создать возможность авторизации пользователя. Создать отдельный раздел "отчёты". Предоставить возможность пользователю создавать различные отчёты по истории загрузки файлов:

* Пользователь должен иметь возможность получить информацию о том кто загрузил файл, имя файла, директория сохранения, методе скачивания и дате загрузки. 
* Пользователь должен иметь возможность применения фильтров по этим данным (для даты фильтр по временному интервалу).
* Отдельным отчётом необходимо реализовать отчёт по методам загрузки: каким из методов сколько файлов было загружено.

3. Усовершенствовать реализацию приложения таким образом, чтобы вне зависимости от того используется ли веб-приложение, либо же приложение оконного типа, логика загрузки файла различными способами находилась в отдельном компоненте (библиотека).

4. Использовать результаты выполнения заданий выше как бэкенд веб-приложения с фронтендом на Angular. К бэкенду прикрутить REST API, через которое фронтенд будет общаться с бэкендом. Разместить приложение в сервисе Azure.

5. Настроить с CI/CD локально с использованием Jenkins/Teamcity и статическим анализатором кода – SonarCube либо библиотека, наподобие StyleCop. В качестве приложения, которое будет настраиваться и прогоняться через анализатор, можно взять клиент-серверное приложение c п.4. Упаковать приложение в Docker-контейнер (в разные контейнеры приложение и БД) и настроить сборку контейнеров и развертывание в рамках CI/CD. 
