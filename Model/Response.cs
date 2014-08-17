namespace HttpClientToolkit.Model {
    /// <summary>
    /// Response of http request. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T> {
        private Error _error;

        /// <summary>
        /// whether the requst is succeed?
        /// </summary>
        public bool Succeed { get; set; }

        /// <summary>
        /// error of the request. 
        /// </summary>
        public Error Error {
            get { return _error ?? (_error = new Error()); }
            set { _error = value; }
        }

        /// <summary>
        /// result of the request
        /// </summary>
        public T Result { get; set; }
    }
}