pipeline {
    agent any
    stages {
        stage('Checkout code') {
            steps {
                echo 'Hi, GeekFlare. Starting to build the App.'
                checkout scm
            }
        }
        stage('1111') {
            steps {
                sh "cat UnitTest1.cs"
                sh "ls -la"
            }
        }
        stage('Run My Test') {
            steps {
                bat "\"C:\\Program Files\\dotnet\\dotnet.exe\" bin\\Debug\\net6.0\\TrelloTestAutomation.dll"
            }
        }
    }
}
