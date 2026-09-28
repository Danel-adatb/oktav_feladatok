import "./App.css";
import { Routes, Route } from "react-router-dom";

import Index from "./pages/Index.jsx";
import Order from "./pages/Order.jsx";
import Flowers from "./pages/Flowers.jsx";
import NotFound from "./pages/NotFound.jsx";

function App() {
    return (
        <>
            <Routes>
                <Route
                    path="/"
                    element={<Index />}
                />

                <Route
                    path="/rendeles/:id"
                    element={<Order />}
                />

                <Route
                    path="/flowers"
                    element={<Flowers />}
                />

                <Route
                    path="*"
                    element={<NotFound />}
                />
            </Routes>
        </>
    );
}

export default App;