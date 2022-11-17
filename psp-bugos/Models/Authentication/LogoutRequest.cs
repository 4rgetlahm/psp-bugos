namespace psp_bugos.Models.Authentication
{
    public record LogoutRequest
    {
        /** <summary>JWT Access Token</summary>
         * <example>eyJ0eXAiOiJKV1QiLCJhbGciOiJub25lIn0.eyJ2ZXIiOjEsImlzcyI6Imh0dHBzOi8vc3lzdGVtLmNvbSIsImF1ZCI6Imh0dHBzOi8vc3lzdGVtLmNvbSIsInN1YiI6IjVhMzc1OGIxLWViYTQtNDZkNC1hNGU4LTQzMjMyN2E1ZDRiMyIsImlhdCI6MTY2NjMwNjg1NSwiZXhwIjoxNjg3NzgzNjYwfQ</example>
         */
        public string? AccessToken { get; set; }
    }
}
