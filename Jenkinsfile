pipeline {
    agent any

    tools {nodejs "NodeJS"}

    triggers {
        pollSCM "*/5 * * * *"
    }

    stages {
        stage('Building: API') {
            steps{
                sh "echo '[API] Building...'"
                sh "dotnet build BackendAPI/WebApplication.sln"
            }
            post {
            		success {
            		sh "echo 'API built successfully'"
            		}
            	}
        }
	
	stage('Back-end tests') {
    		steps{
    		    dir ("BackendAPI/Core.Test/BackendTests") {
    		        sh "dotnet test"
    		    }
    		}
    	}
    	
        stage('Building: Frontend') {
            steps{
                sh "echo '[FRONTEND] Building...'" 
                dir("FrontendHappy"){
                    sh "npm install"
                    sh "ng build"
                }
            }
        }
        
        stage('Deliver: Frontend') {
            steps{
                sh "docker stop front-end"
                sh "docker rm -f front-end"
                sh "docker build -f dockerfile -t frontend-docker-image ."
                sh "docker run --name front-end -d -p 8081:80 frontend-docker-image"
            }
        }

        stage('Deliver: Backend'){
            steps{
                dir("BackendAPI"){
                    sh "docker build -f dockerfile -t backend-docker-image ."
                    sh "docker run --name back-end -d -p 8082:81 backend-docker-image"
                }
            }
        }
        
        stage('Send Discord notification'){
        steps{
            discordSend description: 'The pipeline from Drunken snakes was run', footer: '', image: '', link: '', result: '', scmWebUrl: '', thumbnail: 'https://cdn.discordapp.com/attachments/938788614006014007/954364061661954118/unnamed.jpg', title: 'Drunken Snake', webhookURL: 'https://discord.com/api/webhooks/954363187942260746/DmugEw1tD8X4u__PLbMAjRsS21Q4RnUo7PPmKzjtc8YN6XEERHUFcz2CMZrWMEPTMfWB'
                }
            }
    }
}