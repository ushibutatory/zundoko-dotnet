import IResult from "@/models/IResult";
import ISong from "@/models/ISong";
import axios, { AxiosResponse } from "axios";

export default class ZundokoService {
  private static readonly _baseUrl = "https://vtb0jhpesb.execute-api.ap-northeast-1.amazonaws.com/prod";

  public async list(): Promise<ISong[]> {
    return await axios.get(`${ZundokoService._baseUrl}/list`, {}).then((response: AxiosResponse<ISong[]>) => {
      return response.data;
    });
  }

  public async play(title: string): Promise<void> {
    await axios
      .post(`${ZundokoService._baseUrl}/play`, {
        title: title,
      })
      .then((response: AxiosResponse<IResult>) => {
        console.log(response.data);
      });
  }
}
