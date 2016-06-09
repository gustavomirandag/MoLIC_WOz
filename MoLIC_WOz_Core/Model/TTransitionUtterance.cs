using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoLIC_WOz_Core.Model
{
    public class TTransitionUtterance
    {
        private int _id;
        private int _simulation_id;
        private int _history_id;
        private string _xml_id;
        private string _description;
        private string _emitter;
        private bool _isBreakdown;
        private string _source;
        private string _target;
        private int _legend;
        private string _source_topic;

        public TTransitionUtterance(int id, int simulation_id, int history_id, string xml_id, string description, string emitter, bool isBreakdown, string source, string target, int legend, string source_topic)
        {
            this.id = id;
            this.simulation_id = simulation_id;
            this.history_id = history_id;
            this.xml_id = xml_id;
            this.description = description;
            this.emitter = emitter;
            this.isBreakdown = isBreakdown;
            this.source = source;
            this.target = target;
            this.legend = legend;
            this.source_topic = source_topic;
        }

        public TTransitionUtterance(int simulationId, string xml_id, string description, string emitter, bool isBreakdown, string source, string target)
        {
            this.simulation_id = simulation_id;
            this.xml_id = xml_id;
            this.description = description;
            this.emitter = emitter;
            this.isBreakdown = isBreakdown;
            this.source = source;
            this.target = target;
        }

        public TTransitionUtterance()
        {
        }

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int simulation_id
        {
            get { return _simulation_id; }
            set { _simulation_id = value; }
        }

        public int history_id
        {
            get { return _history_id; }
            set { _history_id = value; }
        }

        public string xml_id
        {
            get { return _xml_id; }
            set { _xml_id = value; }
        }

        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string emitter
        {
            get { return _emitter; }
            set { _emitter = value; }
        }

        public bool isBreakdown
        {
            get { return _isBreakdown; }
            set { _isBreakdown = value; }
        }

        public string source
        {
            get { return _source; }
            set { _source = value; }
        }

        public string target
        {
            get { return _target; }
            set { _target = value; }
        }

        public int legend
        {
            get { return _legend; }
            set { _legend = value; }
        }

        public string source_topic
        {
            get { return _source_topic; }
            set { _source_topic = value; }
        }

        public override string ToString()
        {
            return description;
        }
        
    }
}
