# **Creating a Minimal ASP.NET Web API with JWT Authentication**

## **Welcome**

Welcome to the "Creating a Minimal ASP.NET Web API with JWT Authentication" project! This exercise guides you through developing a lightweight ASP.NET Web API while integrating JWT (JSON Web Token) authentication for secure communication.

## **Features**

### **1. Project Setup**
   - Create a new ASP.NET Web API project.
   - Configure the project with essential dependencies, including the **`Microsoft.AspNetCore.Authentication.JwtBearer`** package for JWT authentication support.

### **2. JWT Authentication Implementation**
   - Develop a **`JwtTokenGenerator`** class responsible for generating and validating JWT tokens.
   - Implement a **`GenerateToken`** method within **`JwtTokenGenerator`** to create a JWT token based on user credentials (e.g., username and password).
   - Utilize the **`System.IdentityModel.Tokens.Jwt`** namespace to sign the JWT token securely using either a key or a certificate.
   - Create a **`ValidateToken`** method to verify the validity of a JWT token, including signature and expiration date.

### **3. API Controller Creation**
   - Establish an API controller class to manage requests and responses for the API.
   - Apply the **`[Authorize]`** attribute to the controller or specific actions requiring authentication.
   - Implement a get method returning today’s weather or a welcome message, showcasing authorized access for users.

### **4. JWT Authentication Configuration**
   - Open the **`Startup.cs`** file and configure JWT authentication using the **`AddAuthentication`** method in the **`ConfigureServices`** method.
   - Specify JWT bearer options and provide essential configuration details like issuer, audience, and token validation parameters.
   - In the **`Configure`** method, integrate the **`UseAuthentication`** middleware to enable authentication within the API.

### **5. Testing the API**
   - Build and run your API project.
   - Utilize tools like Postman or curl to send HTTP requests to API endpoints.
   - For authenticated endpoints, include the JWT token in the request headers using the **`Authorization`** header (format: **`Bearer <token>`**).
   - Conduct tests on both authenticated and unauthenticated endpoints to ensure proper authentication functionality.

## **Prerequisites**

Before you start, ensure you have the following:
   - [.NET Core SDK](https://dotnet.microsoft.com/download) installed.
   - Code editor such as [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/).

## **Getting Started**

1. Clone this project repository:
    ```bash
    git clone https://github.com/Ibrahim-Nobani/Minimal-ASP.NET-Web-API-with-JWT-Authentication.git
    ```

2. Navigate to the project directory:
    ```bash
    cd MinimalWebApiWithJWT
    ```

3. Open the project in your preferred code editor.

## **How to Run**

1. Build the solution:
    ```bash
    dotnet build
    ```

2. Run the API project:
    ```bash
    dotnet run --project MinimalWebApiWithJWT
    ```

3. Access the API at `https://localhost:5001` or the specified port.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.