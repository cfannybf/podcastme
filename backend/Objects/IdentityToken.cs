using System;

namespace backend.Objects
{
    public class IdentityToken
    {
        public string Token { get; set; }

        public int ExpiresIn { get; set; }

        public DateTime CreatedOn { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is IdentityToken))
            {
                return false;
            }

            return (this.Token == ((IdentityToken)obj).Token &&
                    this.ExpiresIn == ((IdentityToken)obj).ExpiresIn &&
                    this.CreatedOn.Equals(((IdentityToken)obj).CreatedOn));
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + (!Object.ReferenceEquals(null, Token) ? Token.GetHashCode() : 0);
            hash = (hash * 7) + (!Object.ReferenceEquals(null, CreatedOn) ? CreatedOn.GetHashCode() : 0);
            hash = (hash * 7) + ExpiresIn;
            return hash;
        }

        public static IdentityToken New
        {
            get 
            {
                return new IdentityToken()
                {
                    Token = Guid.NewGuid().ToString(),
                    //TODO: Config
                    ExpiresIn = 270,
                    CreatedOn = DateTime.Now
                };
            }
        }
    }
}