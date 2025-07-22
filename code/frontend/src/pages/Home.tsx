import { useState, type FormEvent } from "react";
import { type ConvertRequest } from "../types/types";
import ConvertForm from "../components/ConvertForm";
import Result from "../components/ResultMessage";
import ErrorMessage from "../components/ErrorMessage";
import { convertAmount } from "../api/convert";

function Home() {
  const [amount, setAmount] = useState<string>("");
  const [result, setResult] = useState<string>("");
  const [error, setError] = useState<boolean>(false);

  const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();

    setError(false);
    setResult("");

    const request: ConvertRequest = { amount };

    try {
      const data = await convertAmount(request);
      setResult(data.result);
    } catch (err) {
      setError(true);
    }
  };


  return (
    <div className="min-h-screen text-stone-100 flex items-center justify-center p-4 pb-50">
      <div className="p-8 w-full">
        <h2 className="text-3xl font-bold mb-6 text-center">
          Number To Word Converter
        </h2>

        <ConvertForm amount={amount} setAmount={setAmount} onSubmit={handleSubmit} />

        {error && <ErrorMessage error={error} />}
        {!error && result && <Result result={result} />}
      </div>
    </div >
  );
}

export default Home;
