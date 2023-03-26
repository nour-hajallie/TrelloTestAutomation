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
                     cat UnitTest1.cs
                 }
                 }
}
}
