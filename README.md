# Tumblr.NetStandard
A .NET Standard library for the Tumblr API

## Create a new client

```csharp
//Unauthorised client
var credentials = new TumblrClientCredentials(id,secret);
var client = new TumblrClient(credentials);

//authorisedClient
var client = new TumblrClient(credentials, tumblrCredentials);
```

## OAuth Helper methods (Tumblr is still OAuth1.0a)

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