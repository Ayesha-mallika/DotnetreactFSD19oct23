import React, { useState } from 'react';
import MyCalendar from './MyCalendar';
import Events from './Events';
import AddEvents from './AddEvent';

function ParentComponent() {
  const [events, setEvents] = useState([]);

  const fetchEvents = async () => {
    try {
      const response = await fetch('https://localhost:7211/api/Event');
      const data = await response.json();
  
      if (Array.isArray(data)) {
        setEvents(data);
      } else {
        console.error('Invalid data format:', data);
      }
    } catch (error) {
      console.error('Error fetching events:', error);
    }
  };

  const handleEventSelect = (event) => {
    // Handle event selection logic if needed
    console.log('Selected Event:', event);
  };

  return (
    <div>
      <Events />
      <MyCalendar events={events} onEventSelect={handleEventSelect} />
      <button onClick={fetchEvents}>Fetch Events</button>
    </div>
  );
}

export default ParentComponent;