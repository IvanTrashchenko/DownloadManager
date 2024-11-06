pipeline {
    agent any
    stages {
        stage('Checkout Code') {
            steps {
                git 'https://github.com/IvanTrashchenko/DownloadManager.git' 
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
