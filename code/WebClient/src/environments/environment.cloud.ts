export const environment = {
    userauthentication : true,
    pkce: true,
    ISSUER: 'https://myappstest.halliburton.com/oauth2/default',
    CLIENT_ID: '0oa1lkvhinueYqcQm0h8',
    LOGIN_REDIRECT_URI: window.location.origin + '/login/callback',
    scopes: ['openid', 'profile', 'email', 'address', 'phone', 'offline_access'],
    signalRUrl: "https://dev.maxsurvey-api.ienergy.halliburton.com/ServerRealtimeService/",
    baseUrl: "https://dev.maxsurvey-api.ienergy.halliburton.com/api/v3",
    clientUrl : "https://dev.maxsurvey-api.ienergy.halliburton.com/api/v3",
    reportServerUrl : window.location.protocol + "//" + window.location.hostname +":52320/api/v3",
    isLogEnabled : true
};
