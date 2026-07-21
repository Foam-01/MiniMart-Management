import { useState,useEffect } from 'react';
import './App.css';
import MyComponent from './shared/components/MyComponent';

function App() {

  const [counter , setCounter] = useState(0)
    
  return (
    <>
      <div>Counter  = {counter}</div>
      <button onClick={e => setCounter(counter + 1)}>Cllick Here</button>
      <MyComponent />
    </>
  );
}

export default App;
