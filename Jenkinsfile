pipeline
{
    agent any

    environment
    {
        dotnet = 'c:\\Program Files (x86)\\dotnet\\'
    }

    stages
    {
        stage ('Restore packages')
        {
            steps
            {
                bat "dotnet restore Address.API\\Address.API.csproj"
            }
        }

        stage ('Clean')
        {
            steps
            {
                bat "dotnet clean Address.API\\Address.API.csproj"
            }
        }
    }
}