import React, { useState } from "react";
import "./App.css";
import Button from "./Components/button";
import Input from "./Components/input";

function App() {
  const [requestNumber, setRequestNumber] = useState<number>();

  const SubmitRequests = () => {
    if (requestNumber && requestNumber > 0) {
      let promises = [];
      for (let i = 0; i < requestNumber; i++) {
        promises.push(
          fetch(`https://localhost:7074/api/Home`, {
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            method: "POST",
            body: JSON.stringify("data"),
          }).then((response) => console.log(response))
        );
      }
      Promise.all(promises).then(() => alert("requests has been sent"));
    }
  };

  const row = {
    display: "flex",
    justifyContent: "center",
    flexDirection: "column",
    paddingTop: 5,
  } as React.CSSProperties;

  return (
    <div className="App-header">
      <h3>Wotch Home_Task</h3>
      <div style={row}>
        <Input
          requestNumber={requestNumber}
          setRequestNumber={setRequestNumber}
        />
      </div>
      <div style={row}>
        <Button SubmitRequests={SubmitRequests} />
      </div>
    </div>
  );
}

export default App;
