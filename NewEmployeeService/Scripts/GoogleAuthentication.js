function getAccessToken() {
    if (location.hash) {
        if (location.hash.split('access_token=')) {

            var accessToken = location.hash.split('access_token=')[1].split('&')[0];
            var new_access = decodeURIComponent(accessToken);
            if (accessToken) {
                isUserRegistered(accessToken);
            }
        }
    }

    function isUserRegistered(accessToken) {
        $.ajax({
            url: '/api/Account/UserInfo',
            method: 'GET',
            headers: {
                'content-type': 'application/json',
                'Authorization': 'Bearer ' + accessToken
            },
            success: function (response) {
                if (response.HasRegistered ) {
                    localStorage.setItem('accessToken', accessToken);
                    localStorage.setItem('userName', response.Email);
                    window.location.href = 'Data.html';
                } else {
                    signupExternalUser(accessToken, response.LoginProvider);
                   // window.location.href = "hhsha.html";
                }
            }
        });
    }

    function signupExternalUser(accessToken, provider) {
        $.ajax({
            url: '/api/Account/RegisterExternal',
            method: 'POST',
            headers: {
                'content-type': 'application/JSON',
                'Authorization': 'Bearer ' + accessToken
            },
            success: function (response) {
                window.location.href = "/api/Account/ExternalLogin?provider=" + provider+ "&response_type=token&client_id=self&redirect_uri=http%3A%2F%2Flocalhost%3A64687%2FLogin.html&state=aVlxJ6_2ZoUWir9HZAg3B7a3MljKQibljKSb4p5D_FU1";
            }
        });
    }
}