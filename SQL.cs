  string dbHost = "127.0.0.1";//資料庫位址
            string dbUser = "root";//資料庫使用者帳號
            string dbPass = "1234";//資料庫使用者密碼
            string dbName = "new_schema";//資料庫名稱

            string connStr = "server=" + dbHost + ";uid=" + dbUser + ";pwd=" + dbPass + ";database=" + dbName;
            //string connStr = "Server=127.0.0.1;port= 3306;Database=mm;Uid=ZXC;Pwd=1234;";
            MySqlConnection conn = new MySqlConnection(connStr);
            MySqlCommand command = conn.CreateCommand();
            conn.Open();


            String cmdText = "SELECT * FROM new1 WHERE CELLPHONE ="+ text_carnumber.Text;
            MySqlCommand cmd = new MySqlCommand(cmdText, conn);
            MySqlDataReader reader = cmd.ExecuteReader(); //execure the reader