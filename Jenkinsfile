pipeline {
    agent any
    stages {
        stage('Checkout Code') {
            steps {
                git 'https://github.com/IvanTrashchenko/DownloadManager.git' 
            }
        }
        stage('SonarQube Analysis - Backend') {
            steps {
                script {
                    bat 'nuget restore DownloadManager.sln'
                    bat 'SonarScanner.MSBuild.exe begin /k:"DownloadManagerBackend" /d:sonar.login="sqp_118a0c63fed172051976fd47d7211bc9f8f47f4f" /d:sonar.host.url="http://localhost:9000"'
                    bat 'MSBuild.exe /t:Rebuild'
                    bat 'SonarScanner.MSBuild.exe end /d:sonar.login="sqp_118a0c63fed172051976fd47d7211bc9f8f47f4f"'
                }
            }
        }
        stage('SonarQube Analysis - Frontend') {
            steps {
                dir('DownloadManager.Web/ClientApp') {
                    script {
                        bat 'sonar-scanner'
                    }
                }
            }
        }
        stage('Build and Deploy with Docker Compose') {
            steps {
                script {
                    // Stop and remove any running services
                    // bat 'docker-compose down'
                    
                    // Build and deploy the containers using Docker Compose
                    bat 'docker-compose -f compose-web.yaml up --build -d'
                }
            }
        }
    }
    post {
        always {
            echo 'Pipeline finished.'
        }
        success {
            echo 'Web app deployed successfully!'
        }
        failure {
            echo 'Deployment failed.'
        }
    }
}
