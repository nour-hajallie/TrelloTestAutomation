pipeline {
    agent any
    environment {
        PATH = "${PATH}:C:/Program Files/dotnet"
    }
    stages {
        stage('Checkout code') {
            steps {
                echo 'Hi, GeekFlare. Starting to build the App.'
                checkout scm
            }
        }
        stage('Run My Test') {
            steps {
                sh 'chromedriver --version'
                sh 'google-chrome --version'
                sh 'dotnet test'
            }
        }
    }
}
