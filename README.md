# Tumblr.NetStandard
A .NET Standard library for the Tumblr API

## Create a new client - OAuth2 
```csharp
//Unauthorised client
var credentials = new TumblrClientCredentials(clientId);
var client = new TumblrClient(credentials);

//authorisedClient
var client = new TumblrClient(credentials, new TumblrOAuth2Credentials(accessToken));
```

## Create a new client - OAuth1

```csharp
//Unauthorised client
var credentials = new TumblrClientCredentials(id,secret);
var client = new TumblrClient(credentials);

//authorisedClient
var client = new TumblrClient(credentials, tumblrCredentials);
```

## OAuth2 Helper Methods
```csharp
//View an authorize url
LoginView.Source = OAuth2.BuildAuthorizeUri(
    ClientId,
    $"{OAuth2.Scopes.Basic} {OAuth2.Scopes.Write} {OAuth2.Scopes.OfflineAccess}",
    CurrentState);

//Use authorize token to get access token
var content = OAuth2.BuildAuthTokenForm(ClientId, ClientSecret, code);
var client = new HttpClient();
var response = await client.PostAsync(OAuth2.TokenUrl,content);
var detail = await response.Content.ReadAsStringAsync();

```

## OAuth1 Helper methods

```csharp
 var authorizer = new OAuthAuthorizer(credentials);

 // get request token
 var tokenResponse = await authorizer.GetRequestToken("https://www.tumblr.com/oauth/request_token");

 var startUri = new Uri(authorizer.BuildAuthorizeUrl("https://www.tumblr.com/oauth/authorize", tokenResponse.Token));

 //...Use system to get authorise token and oauth_verifier whichever way works for your interface...

 var accessToken = await authorizer.GetAccessToken("https://www.tumblr.com/oauth/access_token",new RequestToken(authorisedToken, tokenSecret), oauthVerifier);
 return new TumblrCredentials(accessToken.Token.Key, accessToken.Token.Secret);
```

## Getting Posts

```csharp
var posts = await client.ForBlog("staff.tumblr.com").Posts();
```

## Liking a post

```csharp
var liked = await client.ForPost(post).Like();
```

## Returning Legacy Post types

```csharp
    Client.ReturnNpfPostLists = false;
```