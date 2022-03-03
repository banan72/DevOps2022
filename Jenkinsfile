pipeline {
    agent any
    triggers {
        pollSCM "*/5 * * * *"
    }
    stages {
        stage('Build Api') {
            steps{
                sh "echo '[API] Building...'"
            }
        }
        stage('Build Frontend') {
            steps{
                sh "echo '[FRONTEND] Building...'" 
            }
        }
    }
}