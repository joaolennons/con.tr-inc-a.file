echo acessando o caminho da api
cd backend/src/api/

echo publicando o backend
dotnet publish --output="../../../dist/backend"

echo iniciando o backend
cd ../../../dist/backend
start dotnet api.dll

echo subindo o frontend
cd ../../frontend/costela
npm install && ng s --open

echo voltando para o root path
cd ../../