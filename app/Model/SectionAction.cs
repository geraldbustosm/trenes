using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    class SectionAction
    {
        private int id;
        private int action_id;
        private int travel_section_id;
        private int locomotive_id;
        private int wagon_id;
        private Boolean deleted;

        public SectionAction (int id, int action_id, int travel_section_id, int locomotive_id, int wagon_id)
        {
            this.id = id;
            this.action_id = action_id;
            this.travel_section_id = travel_section_id;
            this.locomotive_id = locomotive_id;
            this.wagon_id = wagon_id;
        }

        // Public Methods

        public int getId() { return id; }
        public int getAction_id() { return action_id; }
        public int getTravel_section_id() { return travel_section_id; }
        public int getLocomotive_id() { return locomotive_id; }
        public int getWagon_id() { return wagon_id; }

        public void setAction_id(int action_id) { this.action_id = action_id; }
        public void setTravel_section_id(int travel_section_id) { this.travel_section_id = travel_section_id; }
        public void setLocomotive_id(int locomotive_id) { this.locomotive_id = locomotive_id; }
        public void setWagon_id(int wagon_id) { this.wagon_id = wagon_id; }

        // Static Methods

        // Private Methods

    }
}
