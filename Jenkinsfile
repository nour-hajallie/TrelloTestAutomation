pipeline {
  agent any
  stages {
    stage('Check if unitclass is here') {
      steps {
        script {
          try {
            Class.forName('UnitTest1.cs')
            println 'Class is displayed'
          } catch (ClassNotFoundException e) {
            println 'Class is not displayed'
          }
        }
      }
    } 
  }
}