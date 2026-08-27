import './App.css';
import ApplicationPageComponents from './components/ApplicationPageComponents';
import { Toaster } from "react-hot-toast";

function App() {
    return (
        <div className="App">
            <Toaster />

            <h1>Application Tracker</h1>

            <ApplicationPageComponents />

            <button>Delete Application</button>
            <button>Update Application</button>
        </div>
    );
}

export default App;