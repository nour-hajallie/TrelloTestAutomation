pipeline {
    agent any
    stages {
        stage('Checkout code') {
            steps {
                echo 'Hi, GeekFlare. Starting to build the App.'
                checkout scm
            }
        }
        stage('Run My Test') {
            steps {
                echo $PATH
                sh 'chromedriver --version'
                sh 'google-chrome --version'
                sh 'dotnet test'
            }
        }
    }
}
