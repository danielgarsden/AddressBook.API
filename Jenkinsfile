pipeline
{
    agent
    {
        docker
        {
            image 'mcr.microsoft.com/dotnet/sdk:5.0'
        }
    }

    stages
    {
        stage ('Verify')
        {
            steps
            {
                sh "dotnet --list-sdks"
            }
        }
    }
}