using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Globalization;
using MoLIC_WOz_Core.Model;

namespace MoLIC_WOz_Core.Control
{
    public class DbControl
    {
        private static string databasePath;
        private static DbControl instance = null;
        private static string connectionString;

        /// <summary>
        /// DbControl
        /// </summary>
        private DbControl()
        {
        }

        public static bool setDataBasePath(string dbPath)
        {
            MySql.Data.MySqlClient.MySqlConnection dbConnection = null;
            
            try
            {  
                databasePath = dbPath;
                //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath + ";User Id=admin;Password=";
                connectionString = "Server=tx-gu;Database=molic_woz_db;Uid=root;Pwd=kll312;Port=3306;";
                dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                //'''''' Testa banco de dados '''''''
                MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
                dbCommand.Connection = dbConnection;
                //------------------------------

                dbConnection.Open();
                dbCommand.CommandText = "SELECT * FROM TB_SIMULATIONS";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "SELECT * FROM TB_DIALOGS";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "SELECT * FROM TB_SIGNS";
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
                //'''''''''''''''''''''''''''''''''''

                return true;
            }
            catch(Exception ex)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return false; //Arquivo de dados inválido
            }
        }

        public string getDataBaseConnectionString()
        {
            return connectionString;
        }

        public static DbControl getInstance()
        {
            if (instance == null)
                instance = new DbControl();
            return instance;
        }

        /*public void openConnection()
        {
            if (dbConnection != null)
                dbConnection.Open();
        }

        public void closeConnection()
        {
            if (dbConnection != null)
                dbConnection.Close();
        }*/

        /// <summary>
        /// Get Open Simulations
        /// For DESIGNER use
        /// </summary>
        /// <returns></returns>
        public List<TSimulation> getOpenSimulations()
        {

            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            dbCommand.Connection = dbConnection;
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            //------------------------------

            
            dbCommand.CommandText = "SELECT * FROM TB_SIMULATIONS WHERE (status = 'open')";
            try
            {
                dbConnection.Open();
                TSimulation tSimulation;
                int simulationId;
                List<TSimulation> tSimulations = new List<TSimulation>();
                dbDataReader = dbCommand.ExecuteReader();


                while (dbDataReader.Read())
                {

                    simulationId = Convert.ToInt32(dbDataReader["id"]);
                    tSimulation = getSimulation(simulationId);
                    tSimulations.Add(tSimulation);
                }
                dbDataReader.Close();
                dbConnection.Close();
                return tSimulations;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }

        }

        /// <summary>
        /// Return a specific simulation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TSimulation getSimulation(int id)
        {

            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_SIMULATIONS WHERE (id = " + id + ")";
            try
            {
                dbConnection.Open();
                TSimulation tSimulation;
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                tSimulation = new TSimulation(Convert.ToInt32(dbDataReader["id"]), dbDataReader["user_id"].ToString(), dbDataReader["designer_id"].ToString(), dbDataReader["next_speaker"].ToString(), dbDataReader["status"].ToString());
                tSimulation.startDateTime = Convert.ToDateTime(dbDataReader["startDateTime"]);
                if (dbDataReader["finishDateTime"].ToString() != "")
                    tSimulation.finishDateTime = Convert.ToDateTime(dbDataReader["finishDateTime"]);
                dbDataReader.Close();
                dbConnection.Close();
                return tSimulation;
            }
            catch (Exception e)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        /// <summary>
        /// Set Simulation
        /// For USER and DESIGNER use
        /// </summary>
        /// <param name="tSimulation"></param>
        /// <returns></returns>
        public bool setSimulation(TSimulation tSimulation)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "UPDATE TB_SIMULATIONS SET user_id = '" + tSimulation.user_id + "', designer_id = '" + tSimulation.designer_id + "', next_speaker = '" + tSimulation.next_speaker + "', status = '" + tSimulation.status + "', startDateTime = '" + tSimulation.startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "', finishDateTime = '" + tSimulation.finishDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id = " + tSimulation.id.ToString();
            try
            {
                dbConnection.Open();
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
                return true;
            }
            catch(Exception e)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return false;
            }
        }

        /// <summary>
        /// Create Simulation
        /// For USER use
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Simulation ID</returns>
        public int createSimulation(string userId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //-----------------------------

            int simulationId = -1;
            try
            {
                dbConnection.Open();
                DateTime startDateTime = DateTime.Now;
                dbCommand.CommandText = "INSERT INTO TB_SIMULATIONS (user_id, designer_id, next_speaker, status, startDateTime) VALUES('" + userId + "', '','designer', 'open', '" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "SELECT * FROM TB_SIMULATIONS WHERE (user_id = '" + userId + "') AND (startDateTime = '" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                dbDataReader = dbCommand.ExecuteReader();
                if (!dbDataReader.HasRows)
                {
                    IFormatProvider culture = new CultureInfo ("en-US");
                    dbDataReader.Close();
                    dbCommand.CommandText = "SELECT * FROM TB_SIMULATIONS WHERE (user_id = '" + userId + "') AND (startDateTime = '" + startDateTime.GetDateTimeFormats(culture)[74].ToString() +"')";
                    dbDataReader = dbCommand.ExecuteReader();
                }
                dbDataReader.Read();
                simulationId = Convert.ToInt32(dbDataReader["id"]);
                dbDataReader.Close();
            }
            catch(Exception e)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return -1;
            }
            dbDataReader.Close();
            dbConnection.Close();
            return simulationId;

        }

        /// <summary>
        /// Start Simulation
        /// For DESIGNER use
        /// </summary>
        /// <param name="tSimulation"></param>
        /// <param name="designerId"></param>
        public void startSimulation(TSimulation tSimulation, string designerId)
        {
            tSimulation.designer_id = designerId;
            tSimulation.status = "established";
            setSimulation(tSimulation);
        }

        /// <summary>
        /// Fisnish Simulation
        /// </summary>
        /// <param name="id">Simulation Id</param>
        public void finishSimulation(int id)
        {
            TSimulation tSimulation = getSimulation(id);
            tSimulation.status = "close";
            tSimulation.finishDateTime = DateTime.Now;
            setSimulation(tSimulation);
        }

        public void cancelSimulation(int id)
        {
            TSimulation tSimulation = getSimulation(id);
            tSimulation.status = "canceled";
            tSimulation.finishDateTime = DateTime.Now;
            setSimulation(tSimulation);
        }

        /// <summary>
        /// Check if next speaker is the SPEAKER paran
        /// For DESGINER and USER use
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="speaker"></param>
        /// <returns></returns>
        public bool checkNextSpeaker(int simulationId, string speaker)
        {
            TSimulation tSimulation = getSimulation(simulationId);

            if (tSimulation.next_speaker == speaker)
                return true;
            return false;
        }

        /// <summary>
        /// Call next speaker param
        /// For DESIGNER and USER use
        /// </summary>
        /// <param name="simulationId"></param>
        /// <param name="nextSpeaker"></param>
        public void callNextSpeaker(int simulationId, string nextSpeaker)
        {
            TSimulation tSimulation = getSimulation(simulationId);
            tSimulation.next_speaker = nextSpeaker;
            setSimulation(tSimulation);
        }

        public TTransitionUtterance getTransitionUtterance(int transitionId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //-----------------------------

            dbCommand.CommandText = "SELECT * FROM TB_TRANSITION_UTTERANCES WHERE (id = " + transitionId + ")";
            try
            {
                dbConnection.Open();
                TTransitionUtterance tTransitionUtterance;
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                tTransitionUtterance = new TTransitionUtterance(transitionId, Convert.ToInt32(dbDataReader["simulation_id"]), Convert.ToInt32(dbDataReader["history_id"]), Convert.ToString(dbDataReader["xml_id"]), Convert.ToString(dbDataReader["description"]), dbDataReader["emitter"].ToString(), Convert.ToBoolean(dbDataReader["isBreakdown"]), dbDataReader["source"].ToString(), dbDataReader["target"].ToString(), Convert.ToInt32(dbDataReader["legend"]), dbDataReader["source_topic"].ToString());
                dbDataReader.Close();
                dbConnection.Close();
                return tTransitionUtterance;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        /// <summary>
        /// Get Dialog by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TDialog getDialog(int id)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_DIALOGS WHERE (id = " + id + ")";
            try
            {
                dbConnection.Open();
                TDialog tDialog;
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                tDialog = new TDialog(Convert.ToInt32(dbDataReader["id"]), Convert.ToInt32(dbDataReader["transition_id"]), dbDataReader["dialog"].ToString(), null);
                dbDataReader.Close();
                dbCommand.CommandText = "SELECT * FROM TB_SIGNS WHERE (dialog_id = " + tDialog.id + ")";
                dbDataReader = dbCommand.ExecuteReader();
                tDialog.signs = new List<TSign>();
                while (dbDataReader.Read())
                {
                    tDialog.signs.Add(new TSign(Convert.ToInt32(dbDataReader["id"]), tDialog.id, dbDataReader["sign"].ToString(), dbDataReader["sign_value"].ToString()));
                }
                if (tDialog.signs.Count <= 0)
                    tDialog.signs = null;
                dbDataReader.Close();
                dbConnection.Close();
                return tDialog;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        /// <summary>
        /// Get Sign by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TSign getSign(int id)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_SIGNS WHERE (id = '" + id + "')";
            try
            {
                dbConnection.Open();
                TSign tSign;
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                tSign = new TSign(Convert.ToInt32(dbDataReader["dialog_id"]), Convert.ToInt32(dbDataReader["id"]), dbDataReader["sign"].ToString(), dbDataReader["sign_value"].ToString());
                dbDataReader.Close();
                dbConnection.Close();
                return tSign;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        /// <summary>
        /// Get all signs of a specific dialog
        /// </summary>
        /// <param name="dialogId"></param>
        /// <returns></returns>
        public List<TSign> getDialogSigns(int dialogId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_SIGNS WHERE (dialog_id = '" + dialogId + "')";
            try
            {
                dbConnection.Open();
                TSign tSign;
                List<TSign> tSigns = new List<TSign>();
                dbDataReader = dbCommand.ExecuteReader();
                while (dbDataReader.Read())
                {
                    tSign = new TSign(Convert.ToInt32(dbDataReader["dialog_id"]), Convert.ToInt32(dbDataReader["id"]), dbDataReader["sign"].ToString(), dbDataReader["sign_value"].ToString());
                    tSigns.Add(tSign);
                }
                dbDataReader.Close();
                dbConnection.Close();
                return tSigns;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        public List<TDialog> getUserTransitionUtteranceDialogs(int transitionUtteranceId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_DIALOGS WHERE (transition_id = " + transitionUtteranceId.ToString() + ")";
            try
            {
                dbConnection.Open();
                TDialog tDialog;
                List<TDialog> tDialogs = new List<TDialog>();
                dbDataReader = dbCommand.ExecuteReader();
                while (dbDataReader.Read())
                {
                    tDialog = getDialog(Convert.ToInt32(dbDataReader["id"]));
                    tDialogs.Add(tDialog);
                }
                dbDataReader.Close();
                dbConnection.Close();
                if (tDialogs.Count > 0)
                    return tDialogs;
                else
                    return null;
            }
            catch (Exception ex)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        /// <summary>
        /// Get User Dialog Options
        /// For USER use
        /// </summary>
        /// <param name="simulationId"></param>
        /// <returns></returns>
        public List<TTransitionUtterance> getUserTransitionUtteranceOptions(int simulationId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_TRANSITION_UTTERANCES WHERE (simulation_id = " + simulationId.ToString() + ") AND (history_id = -1)";
            try
            {
                dbConnection.Open();
                TTransitionUtterance tTransitionUtterance;
                List<TTransitionUtterance> tTransitionUtterances = new List<TTransitionUtterance>();
                dbDataReader = dbCommand.ExecuteReader();
                while (dbDataReader.Read())
                {
                    tTransitionUtterance = getTransitionUtterance(Convert.ToInt32(dbDataReader["id"]));
                    tTransitionUtterances.Add(tTransitionUtterance);
                }
                dbDataReader.Close();
                dbConnection.Close();
                return tTransitionUtterances;
            }
            catch(Exception ex)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        public void selectUserTransitionUtteranceOption(int transitionId, string userNote)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            dbCommand.Connection = dbConnection;
            //-----------------------------
            int queryResult = -1;
            try
            {
                dbConnection.Open();
                TTransitionUtterance tTransitionUtterance = getTransitionUtterance(transitionId);

                THistory tHistory = new THistory(tTransitionUtterance.simulation_id, tTransitionUtterance.id, userNote, -1, "", DateTime.Now);
                addHistory(tHistory);

                do
                {
                    dbCommand.CommandText = "DELETE FROM TB_TRANSITION_UTTERANCES WHERE simulation_id = " + tTransitionUtterance.simulation_id + " AND history_id = -1";
                    queryResult = dbCommand.ExecuteNonQuery();
                    //Futuramente deletar os que não possuem correspondência.
                } while (queryResult < 0);
            }
            catch
            {
                System.Threading.Thread.Sleep(20000);
            }
            dbConnection.Close();
        }

        public int addUserTransitionUtteranceOption(TTransitionUtterance tTransitionUtterance, List<TDialog> tDialogs)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //-----------------------------

            int transitionId = -1;
            int queryResult = 0;
            try
            {
                dbConnection.Open();
                while (queryResult <= 0)
                {
                    dbCommand.CommandText = "INSERT INTO TB_TRANSITION_UTTERANCES (simulation_id, history_id, xml_id, description, emitter, isBreakdown, source, target, legend, source_topic) VALUES(" + tTransitionUtterance.simulation_id.ToString() + ", -1, '" + tTransitionUtterance.xml_id + "', '" + tTransitionUtterance.description + "', '" + tTransitionUtterance.emitter + "'," + tTransitionUtterance.isBreakdown.ToString() + ", '" + tTransitionUtterance.source + "', '" + tTransitionUtterance.target + "', " + tTransitionUtterance.legend + ",'" + tTransitionUtterance.source_topic + "')";
                    queryResult = dbCommand.ExecuteNonQuery();
                }
                dbCommand.CommandText = "SELECT * FROM TB_TRANSITION_UTTERANCES WHERE (simulation_id = " + tTransitionUtterance.simulation_id.ToString() + ") AND (xml_id = '" + tTransitionUtterance.xml_id + "') AND (history_id = -1)";
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                transitionId = Convert.ToInt32(dbDataReader["id"]);
                dbDataReader.Close();
                if (tDialogs != null)
                {
                    for (int countDialogs = 0; countDialogs < tDialogs.Count; countDialogs++)
                    {
                        dbCommand.CommandText = "INSERT INTO TB_DIALOGS (transition_id, dialog) VALUES(" + transitionId + ", '" + tDialogs[countDialogs].dialog + "')";
                        dbCommand.ExecuteNonQuery();
                        if (tDialogs[countDialogs].signs != null)
                        {
                            dbDataReader.Close();
                            dbCommand.CommandText = "SELECT * FROM TB_DIALOGS WHERE (transition_id = " + transitionId + ") AND (dialog = '" + tDialogs[countDialogs].dialog + "')";
                            dbDataReader = dbCommand.ExecuteReader();
                            dbDataReader.Read();
                            int dialogId = Convert.ToInt32(dbDataReader["id"]);

                            dbDataReader.Close();
                            for (int countSigns = 0; countSigns < tDialogs[countDialogs].signs.Count; countSigns++)
                            {
                                dbCommand.CommandText = "INSERT INTO TB_SIGNS (dialog_id, sign, sign_value) VALUES(" + dialogId.ToString() + ", '" + tDialogs[countDialogs].signs[countSigns].sign + "', '" + tDialogs[countDialogs].signs[countSigns].sign_value + "')";
                                dbCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                dbDataReader.Close();
                dbConnection.Close();
            }
            catch(Exception e)
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
            }
            return queryResult;
        }

        /// <summary>
        /// Add a TransitionUtterance
        /// </summary>
        /// <param name="tTransitionUtterance"></param>
        /// <param name="tDialogs"></param>
        /// <returns></returns>
        public int addTransitionUtterance(TTransitionUtterance tTransitionUtterance, List<TDialog> tDialogs)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //-----------------------------

            int transitionId = -1;
            try
            {
                dbConnection.Open();
                dbCommand.CommandText = "INSERT INTO TB_TRANSITION_UTTERANCES (simulation_id, history_id, xml_id, description, emitter, isBreakdown, source, target, legend, source_topic) VALUES(" + tTransitionUtterance.simulation_id.ToString() + ", -1, '" + tTransitionUtterance.xml_id + "', '" + tTransitionUtterance.description + "', '" + tTransitionUtterance.emitter + "'," + tTransitionUtterance.isBreakdown.ToString() + ", '" + tTransitionUtterance.source + "', '" + tTransitionUtterance.target + "', " + tTransitionUtterance.legend + ",'" + tTransitionUtterance.source_topic + "')";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "SELECT * FROM TB_TRANSITION_UTTERANCES WHERE (simulation_id = " + tTransitionUtterance.simulation_id.ToString() + ") AND (xml_id = '" + tTransitionUtterance.xml_id + "') AND (history_id = -1)";
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                transitionId = Convert.ToInt32(dbDataReader["id"]);
                if (tDialogs != null)
                {
                    for (int countDialogs = 0; countDialogs < tDialogs.Count; countDialogs++)
                    {
                        dbCommand.CommandText = "INSERT INTO TB_DIALOGS (transition_id, dialog) VALUES(" + transitionId + ", '" + tDialogs[countDialogs].dialog + "')";
                        dbCommand.ExecuteNonQuery();
                        if (tDialogs[countDialogs].signs != null)
                        {
                            dbDataReader.Close();
                            dbCommand.CommandText = "SELECT * FROM TB_DIALOGS WHERE (transition_id = " + transitionId + ") AND (dialog = '" + tDialogs[countDialogs].dialog + "')";
                            dbDataReader = dbCommand.ExecuteReader();
                            int dialogId = Convert.ToInt32(dbDataReader["id"]);

                            for (int countSigns = 0; countSigns < tDialogs[countDialogs].signs.Count; countSigns++)
                            {
                                dbCommand.CommandText = "INSERT INTO TB_SIGNS (dialog_id, sign, sign_value) VALUES(" + dialogId.ToString() + ", '" + tDialogs[countDialogs].signs[countSigns].sign + "', '" + tDialogs[countDialogs].signs[countSigns].sign_value + "')";
                                dbCommand.ExecuteNonQuery();
                            }
                        }
                    }
                }
                dbDataReader.Close();
            }
            catch (Exception e)
            {
                System.Threading.Thread.Sleep(20000);
            }
            dbConnection.Close();
            return transitionId;
        }

        public void addHistory(THistory tHistory)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //-----------------------------

            int historyId = -1;

            try
            {
                dbConnection.Open();
                dbCommand.CommandText = "INSERT INTO TB_HISTORYS (simulation_id, user_tu_id, user_note, designer_tu_id, designer_note, dialogDateTime) VALUES(" + tHistory.simulation_id.ToString() + ", " + tHistory.user_tu_id.ToString() + ", '" + tHistory.user_note + "', " + tHistory.designer_tu_id.ToString() + ", '" + tHistory.designer_note + "', '" + tHistory.dialogDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                dbCommand.ExecuteNonQuery();
                dbCommand.CommandText = "SELECT * FROM TB_HISTORYS WHERE (simulation_id = " + tHistory.simulation_id.ToString() + ") AND (dialogDateTime = '" + tHistory.dialogDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "')";
                dbDataReader = dbCommand.ExecuteReader();
                if (!dbDataReader.HasRows)
                {
                    IFormatProvider culture = new CultureInfo("en-US");
                    dbDataReader.Close();
                    dbCommand.CommandText = "SELECT * FROM TB_HISTORYS WHERE (simulation_id = " + tHistory.simulation_id.ToString() + ") AND (dialogDateTime = '" + tHistory.dialogDateTime.GetDateTimeFormats(culture)[74].ToString() + "')";
                    dbDataReader = dbCommand.ExecuteReader();
                }
                dbDataReader.Read();
                historyId = Convert.ToInt32(dbDataReader["id"]);
                dbDataReader.Close();
                if (tHistory.user_tu_id > 0)
                    dbCommand.CommandText = "UPDATE TB_TRANSITION_UTTERANCES SET history_id = '" + historyId + "' WHERE id = " + tHistory.user_tu_id;
                else
                    dbCommand.CommandText = "UPDATE TB_TRANSITION_UTTERANCES SET history_id = '" + historyId + "' WHERE id = " + tHistory.designer_tu_id;
                dbCommand.ExecuteNonQuery();
                dbConnection.Close();
            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(20000);
            }
        }

        public THistory getLastHistory(int simulationId)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            MySql.Data.MySqlClient.MySqlDataReader dbDataReader;
            dbCommand.Connection = dbConnection;
            //------------------------------

            dbCommand.CommandText = "SELECT * FROM TB_HISTORYS WHERE (simulation_id = " + simulationId.ToString() + ") ORDER BY dialogDateTime DESC";
            try
            {
                dbConnection.Open();
                THistory tHistory;
                dbDataReader = dbCommand.ExecuteReader();
                dbDataReader.Read();
                tHistory = new THistory(Convert.ToInt32(dbDataReader["simulation_id"]), Convert.ToInt32(dbDataReader["user_tu_id"]), dbDataReader["user_note"].ToString(), Convert.ToInt32(dbDataReader["designer_tu_id"]), dbDataReader["designer_note"].ToString(), Convert.ToDateTime(dbDataReader["dialogDateTime"]));
                tHistory.id = Convert.ToInt32(dbDataReader["id"].ToString());
                dbDataReader.Close();
                dbConnection.Close();
                return tHistory;
            }
            catch
            {
                dbConnection.Close();
                System.Threading.Thread.Sleep(20000);
                return null;
            }
        }

        public void setHistory(THistory tHistory)
        {
            //--Data Base Access Variables--
            MySql.Data.MySqlClient.MySqlCommand dbCommand = new MySql.Data.MySqlClient.MySqlCommand();
            MySql.Data.MySqlClient.MySqlConnection dbConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            dbCommand.Connection = dbConnection;
            //-----------------------------

            try
            {
                dbConnection.Open();
                dbCommand.CommandText = "UPDATE TB_HISTORYS SET simulation_id = " + tHistory.simulation_id.ToString() + ", user_tu_id = " + tHistory.user_tu_id.ToString() + ", user_note = '" + tHistory.user_note + "', designer_tu_id = " + tHistory.designer_tu_id.ToString() + ", designer_note = '" + tHistory.designer_note + "', dialogDateTime = '" + tHistory.dialogDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "' WHERE id = " + tHistory.id;
                dbCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Threading.Thread.Sleep(20000);
            }
            dbConnection.Close();
        }
    }
}
