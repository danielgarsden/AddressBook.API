pipeline{
    agent any
    
    environment {
        dotnet ='C:\\Program Files (x86)\\dotnet\\'
        }
        
    stage('Restore packages'){
   	steps{
      	bat "dotnet restore Address.API\\Address.API.csproj"
     }
  }
 }