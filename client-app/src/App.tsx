import React from 'react';
import './App.css';
import BoardList from './components/BoardList/BoardList';
import Header from './components/Header/Header'

function App() {
  return (
    <div className="App">
      <Header />
      <BoardList/>
    </div>
  );
}

export default App;
