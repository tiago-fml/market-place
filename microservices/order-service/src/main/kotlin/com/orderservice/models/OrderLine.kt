package com.orderservice.models

import com.orderservice.dtos.orderlines.OrderLineCreateDto
import com.orderservice.dtos.orderlines.OrderLineDto
import jakarta.persistence.*
import java.util.UUID

@Entity
@Table(name = "orderslines")
class OrderLine (
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    val id:UUID,
    val productId:UUID,
    val productDescription: String,
    val quantity:Long,
    val price:Double,
    
    @ManyToOne
    var order: Order
){
    // Map from DTO to entity
    companion object {
        fun fromCreateDto(dto: OrderLineCreateDto, order: Order): OrderLine {
            return OrderLine(
                id = UUID.randomUUID(),
                productId = dto.productId,
                productDescription = dto.productDescription,
                quantity = dto.quantity,
                price = dto.price,
                order = order
            )
        }
    }
    fun toDto(): OrderLineDto {
        return OrderLineDto(
            id = this.id,
            productId = this.productId,
            productDescription = this.productDescription,
            quantity = this.quantity,
            price = this.price
        )
    }
}