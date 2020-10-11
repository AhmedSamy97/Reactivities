import React, { Component } from 'react';

import './App.css';
import axois from 'axios'
import { Button } from 'semantic-ui-react'
import 'semantic-ui-css/semantic.min.css'

class App extends Component<any,any> {

  state={
    values:[]
  }
    componentDidMount(){
      axois.get("http://localhost:5000/api/values")
      .then((res)=>{
        this.setState({values:res.data});
      })
    }

  render(){
    return (
      <div className="App">
      
       {/* {this.state.values.map((val:any) =><div key={val.id}>{val.id} - {val.name}</div>)} */}
      
      </div>
    );
  }
}

export default App;
