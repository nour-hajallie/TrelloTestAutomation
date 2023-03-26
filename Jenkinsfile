pipeline {
         agent any
         stages {
                 stage('Checkout code') {
                 steps {
                     echo 'Hi, GeekFlare. Starting to build the App.'
                     checkout scm
                 }
                 }
                 stage('Test') {
                 steps {
                    input('Do you want to proceed?')
                 }
                 }
}
}
