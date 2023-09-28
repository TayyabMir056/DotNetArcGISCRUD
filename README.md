# ArcGIS REST API CRUD in C#

This project demonstrates how to interact with an ArcGIS Feature Server using C#. The application performs basic CRUD operations: Create, Read, Update, and Delete features.

## Requirements
- .NET Core SDK
- Newtonsoft.Json package
- An active ArcGIS Feature Server endpoint
- Visual Studio (optional)

## Libraries Used
- System.Net.Http for making HTTP requests
- Newtonsoft.Json for parsing JSON responses

## How to Install Dependencies
1. Open the command line and navigate to your project folder.
2. Run the following command to install Newtonsoft.Json:
    ```
    dotnet add package Newtonsoft.Json
    ```

## Project Structure
The project consists of a single C# file (`Program.cs`) with the following sections:

- **Feature Record**: A record class that defines a feature object containing a `LocationName` and `Address`.
- **Main Method**: This is the entry point of the application. It performs the following operations:
  1. Fetch existing features from the ArcGIS server.
  2. Add a new feature to the ArcGIS server.
  3. Update an existing feature on the ArcGIS server.
  4. Delete an existing feature from the ArcGIS server.

## How to Run

### Method 1: Using Command Line
1. Clone the repository or download the source code.
2. Open the command line and navigate to the project directory.
3. Run the command `dotnet restore` to restore packages.
4. Run the command `dotnet run` to execute the program.

### Method 2: Using Visual Studio
1. Clone the repository or download the source code.
2. Open the `.sln` file using Visual Studio.
3. Build the solution (usually `Ctrl+Shift+B`).
4. Run the application by clicking on the "Start" button or pressing `F5`.

## Configuration
- Change the `url` variable value to point to your own ArcGIS Feature Server.
- Modify the attributes in the `values`, `valuesUpdate`, and `valuesDelete` dictionaries as needed for your specific feature structure.

## Code Highlights

### Fetching Data
This section fetches all features from the ArcGIS server and prints the `Location Name` and `Address` attributes.

```csharp
HttpResponseMessage response = httpClient.GetAsync(url + "query?where=1%3D1&outFields=*&f=json").Result;
```

### Adding Data
This section adds a new feature with given attributes.

```csharp
HttpResponseMessage responseAdd = httpClient.PostAsync(addUrl, requestContent).Result;
```

### Updating Data
This section updates an existing feature (where FID is 1) with new attributes.

```csharp
HttpResponseMessage responseUpdate = httpClient.PostAsync(updateUrl, requestContentUpdate).Result;
```

### Deleting Data
This section deletes an existing feature (where FID is 1).

```csharp
HttpResponseMessage responseDelete = httpClient.PostAsync(deleteUrl, requestContentDelete).Result;
```
