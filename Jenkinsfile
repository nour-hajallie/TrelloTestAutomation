pipeline {
    agent any
    environment {
        PATH = "${PATH};C:\\Program Files\\Mono\\bin"
    }
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
                sh 'mono bin/Debug/net6.0/TrelloTestAutomation.dll'
            }
        }
    }
}
