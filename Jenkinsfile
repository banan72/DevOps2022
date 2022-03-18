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
    		        sh "dotnet add package coverlet.collector"
                    sh "dotnet test --collect:'XPlat Code Coverage'"
    		    }
    		}
    		post {
                success {
                    archiveArtifacts "BackendAPI/Core.Test/BackendTests/TestResults/*/coverage.cobertura.xml"
                    publishCoverage adapters: [coberturaAdapter(path: 'BackendAPI/Core.Test/BackendTests/*/coverage.cobertura.xml', thresholds: [[failUnhealthy: true, thresholdTarget: 'Conditional', unhealthyThreshold: 80.0, unstableThreshold: 50.0]])], sourceFileResolver: sourceFiles('NEVER_STORE')
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
        
        stage("Reset containers"){
            steps{
                script{
                    try{
                        sh "docker-compose down"
                    }
                    finally {}
                }
            }
        }
        
        stage("Deploy"){
            steps{
                sh "docker-compose up -d"
            }
        }
    }
    post {
        always {
            discordSend description: 'The pipeline from Drunken snakes was run', footer: '', image: '', link: '', result: '', scmWebUrl: '', thumbnail: 'https://cdn.discordapp.com/attachments/938788614006014007/954364061661954118/unnamed.jpg', title: 'Drunken Snake', webhookURL: 'https://discord.com/api/webhooks/954363187942260746/DmugEw1tD8X4u__PLbMAjRsS21Q4RnUo7PPmKzjtc8YN6XEERHUFcz2CMZrWMEPTMfWB'
        }
    }
}