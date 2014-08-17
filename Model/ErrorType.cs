namespace HttpClientToolkit.Model {
    /// <summary>
    /// Request error type
    /// </summary>
    public enum ErrorType {
        None,                   //no error
        Timeout,                //request timeout
        JsonDeserizeError,      //error when deserize result    
        RequestError,           //error when meet HttpRequestException
        Unknown                 //unknown error
    }
}