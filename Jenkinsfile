pipeline {
  agent any
  stages {
    stage('Check if unitclass is here') {
      steps {
        script {
          try {
            Class.forName('com.example.UnitTest1')
            println 'Class is displayed'
          } catch (ClassNotFoundException e) {
            println 'Class is not displayed'
          }
        }
      }
    } 
  }
}
