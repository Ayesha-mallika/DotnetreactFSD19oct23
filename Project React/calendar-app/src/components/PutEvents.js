import { useState } from "react";
import './AddEvent.css';

function PutEvents({event}){
    const [Id,setId] = useState(event.id);
    const [title,setTitle] = useState(event.title);
    const [description,setDescription] = useState(event.description);
    const [startdatetime,setStartDateTime] = useState(event.startDateTime);
    const [enddatetime,setEndDateTime] = useState(event.endDateTime);
    const [notificationdatetime,setNotificationDateTime] = useState(event.notificationDateTime);
    const[location,setLocation]=useState(event.location);
    const [isrecurring,setIsRecurring] = useState(false);
    const[recurring_frequency,setRecurring_frequency] = useState(event.recurring_frequency);
    const[categoryId,setCategoryId] = useState(event.categoryId);
    const[email,setEmail]=useState(event.email);

    var event;
    var clickAdd = ()=>{
        alert('You clicked the button');
       event={
        "Id":Id,
        "title":title,
        "description":description,
        "startdatetime":startdatetime,
        "enddatetime" : enddatetime,
        "notificationdatetime" : notificationdatetime,
        "location" : location,
        "isrecurring":isrecurring,
        "recurring_frequency" : recurring_frequency,
        "categoryId":categoryId,
        "email":email
        }
        console.log(event);
        fetch('https://localhost:7211/api/Event',{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(event)
        }).then(
            ()=>{
                alert("Event Updated");
            }
        ).catch((e)=>{
            console.log(e)
        })
    }
    const Delete=()=>{
        alert('You clicked the button');
        event={
         "Id":event.id
         
         }
         console.log(event);
         fetch('https://localhost:7211/api/Event',{
             method:'DELETE',
             headers:{
                 'Accept':'application/json',
                 'Content-Type':'application/json'
             },
             body:JSON.stringify(event)
         }).then(
             ()=>{
                 alert("Event Deleted");
             }
         ).catch((e)=>{
             console.log(e)
         })
    }

    return(
        <div className="inputcontainer">
            <h1>Event</h1>
            <br/>
            <label className="form-control" for="pId">Id</label>
            <input id="pId" type="number" className="form-control" value={Id} onChange={(e)=>{setId(e.target.value)}}/>
            <br/>
            <label className="form-control" for="ptitle">Title</label>
            <input id="ptitle" type="text" className="form-control" value={title} onChange={(e)=>{setTitle(e.target.value)}}/>
            <br/>
            <label className="form-control" htmlFor="pdescription">Description</label>
            <textarea id="pdescription" className="form-control" value={description} onChange={(e) => {setDescription(e.target.value)}}/>
            <br/>
            <label className="form-control"  for="pstartdatetime">StartDateTime</label>
            <input id="pstartdatetime" type="datetime-local" className="form-control" value={startdatetime} onChange={(e)=>{setStartDateTime(e.target.value)}}/>
            <br/>
            <label className="form-control"  for="penddatetime">EndDateTime</label>
            <input id="penddatetime" type="datetime-local" className="form-control" value={enddatetime} onChange={(e)=>{setEndDateTime(e.target.value)}}/>
            <br/>  
            <label className="form-control"  for="notificationdatetime">NotificationDateTime</label>
            <input id="notificationdatetime" type="datetime-local" className="form-control" value={notificationdatetime} onChange={(e)=>{setNotificationDateTime(e.target.value)}}/>
            <br/>
            <label className="form-control"  for="plocation">Location</label>
            <input id="plocation" type="text" className="form-control" value={location} onChange={(e)=>{setLocation(e.target.value)}}/>
            <br/>
            <label className="form-boolean">IsRecurring</label><br/>
            <select className="form-boolean" onChange={(e) => setIsRecurring(e.target.value === 'true')}>
              <option value="false">No</option>
              <option value="true">Yes</option>
            </select>
            <br/>
            {isrecurring && (
            <div>
                <br/>
            <div className="form-group">
            <label for="recurring_frequency">Recurring_frequency</label>
            <select
              id="recurring_frequency"
              className="form-control"
              value={recurring_frequency}
              onChange={(e) => setRecurring_frequency(e.target.value)}
            >
              <option value="daily">Daily</option>
              <option value="weekly">Weekly</option>
              <option value="monthly">Monthly</option>
            </select>
            </div>
            </div>
            )}
            <br/>
            <label className="form-control"  for="pcategoryId">CategoryId</label>
            <input id="pcategoryId" type="number" className="form-control" value={categoryId} onChange={(e)=>{setCategoryId(e.target.value)}}/>
            <br/>
            <label className="form-control"  for="pemail">Email</label>
            <input id="pemail" type="text" className="form-control" value={email} onChange={(e)=>{setEmail(e.target.value)}}/>
            <br/>
            <button onClick={clickAdd} className="btn btn-primary">Update Event</button>
            <button onClick={Delete} className="btn btn-danger">Delete Event</button>
       </div>
    );
}

export default PutEvents;