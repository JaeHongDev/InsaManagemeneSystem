using Oracle.ManagedDataAccess.Client;

namespace InsaManagementSystem.database
{
    public class Connection
    {
        private string id;
        private string hostName;
        private string password;
        private string port;
        private string connectionString;

        /// <summary>
        ///  커넥션의 인자값이 존재하지 않는경우 초기값을 만들어 줍니다.
        /// </summary>
        /// <returns></returns>
        public Connection() : this("TINSA", "localhost", "1234", "1521")
        {
        }

        public Connection(string id, string hostName, string password, string port)
        {
            this.id = id;
            this.hostName = hostName;
            this.password = password;
            this.port = port;
            this.connectionString =
                $"Data Source = {this.hostName}:{this.port}/XE;User id={this.id};Password={this.password}";
        }
        

        /// <summary>
        ///  오라클 커넥션을 생성합니다
        /// </summary>
        /// <returns></returns>
        public OracleConnection getConnection()
        {
            return new OracleConnection(this.connectionString);
        }
    }
}