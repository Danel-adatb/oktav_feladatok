import "../App.css"
import {Link, useNavigate, useParams} from "react-router-dom";
import {useEffect, useState} from "react";

function Order() {
    const { id } = useParams();
    const [loading, setLoading] = useState(true);
    const [data, setData] = useState(null);
    const [quantity, setQuantity] = useState(1);
    const navigate = useNavigate();

    useEffect(() => {
        fetch(`https://localhost:7131/api/flowers/${id}`)
            .then(res => {
                if (!res.ok) {
                    throw new Error("Failed to fetch flower " + id);
                }

                return res.json();
            })
            .then(data => {
                setData(data);
            })
            .catch(err => console.error(err))
            .finally(() => setLoading(false));
    }, [id]);

    const handleOrder = async (e) => {
        e.preventDefault();

        try {
            const response = await fetch(`https://localhost:7131/api/flowers/${id}`, {
                method: "PUT",
                headers: {"Content-Type": "application/json"},
                body: JSON.stringify({
                    name: data[0].pName,
                    description: data[0].description,
                    stock: Number(data[0].stock - quantity),
                    price: data[0].price,
                    imgUrl: data[0].imgUrl,
                    categoryId: data[0].category.categoryId
                })
            });

            if (!response.ok) {
                const error = await response.text();
                throw new Error(error || `HTTP error: ${response.status}`);
            }

            const result = await response.json();
            console.log("Order successful:", result);
            alert("Sikeres rendelés!");

            navigate("/flowers");
        } catch (error) {
            console.error("Order failed:", error);
            alert("A rendelés sikertelen!");
        }
    };

    if (loading) { return <p>Loading...</p>; }

    if (!data) { return <p>No value has been found with ID: {id}</p>; }

    return (
        <>
            <div>
                <header>
                    <Link to="/">
                        <img
                            src="/public/assets/sunflower.jpg"
                            alt="fa"
                            id="logo"
                        />
                    </Link>

                    <h1>Nevenincs Bt.</h1>
                    <h2>Vetőmagok - Mindenféle, minden mennyiségben</h2>
                </header>
                <main className={"container"}>
                    {data == null ? (
                        <>
                            <p>No value has been found with ID: {id}</p>
                        </>
                    ) : (
                        data.map((item) => (
                            <>
                                <h2>{item.pName}</h2>
                                <div className="row">
                                    <div className="col-md-6">
                                        <img src={item.imgUrl} alt={item.pName} className="img-thumbnail"/>
                                    </div>
                                    <div className="col-md-6">
                                        <p>
                                            {item.description}
                                        </p>
                                        <form onSubmit={handleOrder}>
                                            <p className="text-center">
                                                <span id="ar">Ár: {item.price} Ft</span>
                                                {item.stock == 0 ? (
                                                    <p>Jelenleg nincs a termékből készleten, keresse fel oldalunkat később!</p>
                                                ) : (
                                                    <>
                                                        <label htmlFor="mennyiseg">Mennyiség:</label>
                                                        <input
                                                            type="number"
                                                            name="mennyiseg"
                                                            id="mennyiseg"
                                                            min="1"
                                                            max={item.stock}
                                                            value={quantity}
                                                            onChange={(e) => setQuantity(Number(e.target.value))}
                                                        />
                                                        <p className="text-center">
                                                            <button
                                                                type="submit"
                                                                className="btn btn-warning btn-lg"
                                                            >
                                                                Megrendelem
                                                            </button>
                                                        </p>
                                                    </>
                                                )}
                                            </p>
                                        </form>
                                    </div>
                                </div>
                            </>
                        ))
                    )}
                </main>
                <footer className="container-fluid">
                    <div className="row">
                        <div className="col-md-2 col-lg-2">
                            <h3>Nyitvatartás:</h3>
                        </div>

                        <div className="col-md-4 col-lg-4">
                            <ul>
                                <li>Hétfő-Péntek: 8-17 óráig</li>
                                <li>Szombat: 8-13 óráig</li>
                                <li>Vasárnap: 9-12 óráig</li>
                            </ul>
                        </div>

                        <div className="col-md-2 col-lg-2">
                            <h3>Kapcsolat:</h3>
                        </div>

                        <div className="col-md-4 col-lg-4">
                            <ul>
                                <li>06-30/111-1111</li>
                                <li>06-70/111-1111</li>
                                <li>nevenincsbt@gmail.com</li>
                            </ul>
                        </div>
                    </div>
                </footer>
            </div>
        </>
    );
}

export default Order