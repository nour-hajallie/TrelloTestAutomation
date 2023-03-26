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
                // Option 1: Specify the full path to the Mono executable
                echo 'Running the test.'

                sh 'C:\\Program Files\\Mono\\bin\\mono.exe bin/Debug/net6.0/TrelloTestAutomation.dll'
            }
        }
    }
}
