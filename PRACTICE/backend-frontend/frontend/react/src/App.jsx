import "./App.css";
import { Routes, Route } from "react-router-dom";

import Index from "./pages/Index.jsx";
import Megrendeles from "./pages/Megrendeles.jsx";
import Aruk from "./pages/Aruk.jsx";
import NemTalalt from "./pages/NemTalalt.jsx";

function App() {
    return (
        <>
            <Routes>
                <Route
                    path="/index"
                    element={<Index />}
                />

                <Route
                    path="/megrendeles"
                    element={<Megrendeles />}
                />

                <Route
                    path="/aruk"
                    element={<Aruk />}
                />

                <Route
                    path="*"
                    element={<NemTalalt />}
                />
            </Routes>
        </>
    );
}

export default App;