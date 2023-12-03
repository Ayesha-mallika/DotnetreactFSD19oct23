import './App.css';
import { BrowserRouter, Route, Routes } from 'react-router-dom';
import RegisterUser from './components/RegisterUser';
import Events from './components/Events';
import Category from './components/Category';
import Menu from './components/Menu';
import LoginUser from './components/LoginUser';
import ParentComponent from './components/ParentComponent';
import MyCalendar from './components/MyCalendar';
import AddEvent from './components/AddEvent';

function App() {

  return (
    <div>
    { <BrowserRouter>
      <Menu/>
        <Routes>
          
          <Route path="loginUser" element={<LoginUser/>} />
          <Route path="/" element={<RegisterUser/>} />
          <Route path="events" element={<Events/>} />
          <Route path="category" element={<Category/>} />
          <Route path="MyCalendar" element={<MyCalendar/>} />
          
        </Routes>  
      </BrowserRouter> }
    </div>
  );
}

export default App;