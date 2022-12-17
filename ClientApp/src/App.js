import React, { Component } from 'react';
import { Switch, HashRouter as Router, Route } from "react-router-dom";
import Example1 from "./components/Example1/Example1.js";

class App extends Component {
    constructor(props) {
        super(props)
        window.Chargebee.init({
            site: "mycompany123-test",
            publishableKey: "test_fJeNqZI6KSGmPiEKqQQ1cdElyvHjOB2Hc"
        })
    }

    render() {
        return (
            <Router basename="/react/">
                <Switch>
                    <Route path="/example1" component={Example1} />
                    <Route exact path="/" component={Example1} />
                </Switch>
            </Router>
        )
    }
}

export default App;