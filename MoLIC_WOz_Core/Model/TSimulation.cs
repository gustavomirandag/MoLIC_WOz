using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoLIC_WOz_Core.Model
{
    public class TSimulation
    {
        int _id;
        string _user_id;
        string _designer_id;
        string _next_speaker;
        string _status;
        DateTime _startDateTime;
        DateTime _finishDateTime;

        public TSimulation(int id, string user_id, string designer_id, string next_speaker, string status)
        {
            this.id = id;
            this.user_id = user_id;
            this.designer_id = designer_id;
            this.next_speaker = next_speaker;
            this.status = status;
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string designer_id
        {
            get { return _designer_id; }
            set { _designer_id = value; }
        }

        public string next_speaker
        {
            get { return _next_speaker; }
            set { _next_speaker = value; }
        }

        public string status
        {
            get { return _status; }
            set { _status = value; }
        }

        public DateTime startDateTime
        {
            get { return _startDateTime; }
            set { _startDateTime = value; }
        }

        public DateTime finishDateTime
        {
            get { return _finishDateTime; }
            set { _finishDateTime = value; }
        }

        public override string ToString()
        {
            return user_id;
        }
    }
}
